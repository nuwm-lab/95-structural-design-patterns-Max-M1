using System;

namespace AdapterPatternExample
{
    public interface INewJoystick
    {
        void ConnectNewJoystick();
        void PlayGameWithNewJoystick();
    }

    public class NewJoystick : INewJoystick
    {
        public void ConnectNewJoystick()
        {
            Console.WriteLine("Новий джойстик пiдключено.");
        }

        public void PlayGameWithNewJoystick()
        {
            Console.WriteLine("Граємо за допомогою нового джойстика.");
        }
    }

    public class OldJoystick
    {
        public void ConnectOldJoystick()
        {
            Console.WriteLine("Старий джойстик пiдключено.");
        }

        public void PlayGameWithOldJoystick()
        {
            Console.WriteLine("Граємо за допомогою старого джойстика.");
        }
    }

    public class JoystickAdapter : INewJoystick
    {
        private readonly OldJoystick _oldJoystick;

        public JoystickAdapter(OldJoystick oldJoystick)
        {
            _oldJoystick = oldJoystick;
        }

        public void ConnectNewJoystick()
        {
            _oldJoystick.ConnectOldJoystick();
        }

        public void PlayGameWithNewJoystick()
        {
            _oldJoystick.PlayGameWithOldJoystick();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            INewJoystick newJoystick = new NewJoystick();
            newJoystick.ConnectNewJoystick();
            newJoystick.PlayGameWithNewJoystick();

            Console.WriteLine();

            OldJoystick oldJoystick = new OldJoystick();
            INewJoystick adaptedJoystick = new JoystickAdapter(oldJoystick);
            adaptedJoystick.ConnectNewJoystick();
            adaptedJoystick.PlayGameWithNewJoystick();
        }
    }
}
