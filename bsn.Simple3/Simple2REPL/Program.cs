/* 
 * Program: Simple 2 REPL Interpreter 
 * Grammar: Gold Parser Example Grammar "Simple 2" by Devin Cook
 * Author: Dave Dolan (based on Arsene von Wyss's Calculator example and wiki entry tutorials)
 * Date: 2010-08-25
 * Author Interjection: I have no idea what the "&" operator is supposed to do based on the grammar, 
 * so I opted for string concatenation for fun and games. 
 * 
 * Please don't complain that it's all in one file. Get ReSharper and split it up if you want! 
 * 
 * Also worthy of notice is that because of the BSN engine approach, this originally took me only 90 minutes to hack up.
 * I spent a little time after that cleaning it up for the kids at home. Still not all that clean, but it's better.
 * 
 * See http://code.google.com/p/bsn-goldparser for more information.
 * 
 * This is a Gold Parser Builder based project. Check out: http://goldparser.com 
 * 
 * I just added a type checker. It's kinda crappy, but it works for this grammar.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using bsn.GoldParser.Grammar;
using bsn.GoldParser.Semantic;
using SimpleREPL.Simple2;
using SimpleREPL.Simple3;



namespace SimpleREPL{

   

    internal class Program{
        private static void Main(string[] args){

            

            CompiledGrammar grammar = CompiledGrammar.Load(typeof (Simple3Token), "Simple3.cgt");
            var actions = new SemanticTypeActions<Simple3Token>(grammar);
            try{
                actions.Initialize(true);
            }
            catch (InvalidOperationException ex){
                Console.Write(ex.Message);
                Console.ReadKey(true);
                return;
            }

            /* you can try 2 if you like to run an 
             * implementation of the original grammar as created by Devin Cook */
            var runner = ReplFactory.CreateReplByVersion(3);
            runner.Run();

        }
    }
}