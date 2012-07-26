using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternExamples
{
    /// <summary>
    /// Command接口，定义了执行方法
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }

    /// <summary>
    /// 实际上command要执行的相关操作
    /// </summary>
    public class CommandHandler
    {
        public void TrunOn()
        {
            Console.WriteLine("Turn on the light!");
        }
        public void TrunOff()
        {
            Console.WriteLine("Turn off the light!");
        }
    }

    /// <summary>
    /// 具体的命令类 TurnOn
    /// </summary>
    public class TurnOnCommand : ICommand
    {
        private CommandHandler handler;

        public TurnOnCommand(CommandHandler h)
        {
            this.handler = h;
        }
        public void Execute()
        {
            handler.TrunOn();
        }
    }

    /// <summary>
    /// 具体的命令类， TurnOff
    /// </summary>
    public class TurnOffCommand : ICommand
    {
        private CommandHandler handler;

        public TurnOffCommand(CommandHandler h)
        {
            this.handler = h;
        }
        public void Execute()
        {
            handler.TrunOff();
        }
    }

    /// <summary>
    /// 开关类，也就是invoker类，储存和调用command
    /// </summary>
    public class Switcher
    {
        /// <summary>
        /// 为什么要储存command， 为了undo做准备，好知道都执行了哪些command
        /// </summary>
        private List<ICommand> commandArray = new List<ICommand>();

        public void StoreAndExecuteCommand(ICommand command)
        {
            commandArray.Add(command);
            command.Execute();
        }
    }


    public class CommandClientTest
    { 
        public static void test()
        {
            Console.WriteLine(Utility.HeaderString("Command"));
            Switcher sw = new Switcher();
            CommandHandler handler = new CommandHandler();
            
            //new command 

            TurnOnCommand onCommand = new TurnOnCommand(handler);
            TurnOffCommand offCommand = new TurnOffCommand(handler);

            sw.StoreAndExecuteCommand(onCommand);
            sw.StoreAndExecuteCommand(offCommand);
            
        }
    }
}
