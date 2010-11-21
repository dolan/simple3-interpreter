// /************************************************************
// *  
// * Copyright (c) 2010 Dave Dolan. All Rights Reserved
// *  
// *  Author: Dave Dolan
// *   
// ************************************************************/
using System;
using bsn.GoldParser.Semantic;

namespace SimpleREPL.Simple3{
    public class BinaryOperation : Expression{
        private readonly Expression _left;
        private readonly BinaryOperator _op;
        private readonly Expression _right;


        [Rule(@"<Expression> ::= <Expression> '>' <Add Exp>")]
        [Rule(@"<Expression> ::= <Expression> '<' <Add Exp>")]
        [Rule(@"<Expression> ::= <Expression> '<=' <Add Exp>")]
        [Rule(@"<Expression> ::= <Expression> '>=' <Add Exp>")]
        [Rule(@"<Expression> ::= <Expression> '==' <Add Exp>")]
        [Rule(@"<Expression> ::= <Expression> '<>' <Add Exp>")]
        [Rule(@"<Add Exp> ::= <Add Exp> '+' <Mult Exp>")]
        [Rule(@"<Add Exp> ::= <Add Exp> '-' <Mult Exp>")]
        [Rule(@"<Add Exp> ::= <Add Exp> '&' <Mult Exp>")]
        [Rule(@"<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>")]
        [Rule(@"<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>")]
        public BinaryOperation(Expression left, BinaryOperator op, Expression right){
            _left = left;
            _op = op;
            _right = right;
        }

        public override object GetValue(Simple3ExecutionContext ctx){
            object lStart = _left.GetValue(ctx);
            object rStart = _right.GetValue(ctx);

            object lFinal;
            object rFinal;

            if (!_op.SkipConversion){
                TypeChecker.GreatestCommonType gct = TypeChecker.GCT(lStart, rStart);

                switch (gct){
                    case TypeChecker.GreatestCommonType.StringType:
                        lFinal = Convert.ToString(lStart);
                        rFinal = Convert.ToString(rStart);
                        break;
                    case TypeChecker.GreatestCommonType.BooleanType:
                        lFinal = Convert.ToBoolean(lStart);
                        rFinal = Convert.ToBoolean(rStart);
                        break;
                    case TypeChecker.GreatestCommonType.NumericType:
                        lFinal = Convert.ToDouble(lStart);
                        rFinal = Convert.ToDouble(rStart);

                        break;
                    default:
                        throw new TypeMismatchException( );
                }
            }
            else{
                // lets not put square pegs in round holes. Sometimes the operators can 'universally convert'
                // like the '&' operator will always convert to a string. Always.
                lFinal = lStart;
                rFinal = rStart;
            }
            return _op.Evaluate(lFinal, rFinal);
        }
    }
}