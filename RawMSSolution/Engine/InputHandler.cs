using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace MSEngine
{
    public class InputHandler : GameComponent
    {
        public static KeyboardState KeyboardState { get; private set; }

        public static KeyboardState LastKeyboardState { get; private set; }

        public static GamePadState[] GamePadStates { get; private set; }

        public static GamePadState[] LastGamePadStates { get; private set; }

        private PlayerIndex[] playerIndexes {get;set;}

        public InputHandler(Game game) : base(game)
        {
            KeyboardState = Keyboard.GetState();
            playerIndexes = (PlayerIndex[])Enum.GetValues(typeof(PlayerIndex));

            GamePadStates = new GamePadState[playerIndexes.Length];

            foreach(PlayerIndex index in playerIndexes)
            {
                GamePadStates[(int)index] = GamePad.GetState(index);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            LastKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState();

            LastGamePadStates = (GamePadState[])GamePadStates.Clone();

            foreach (PlayerIndex index in playerIndexes)
            {
                GamePadStates[(int)index] = GamePad.GetState(index);
            }

            base.Update(gameTime);
        }

        public static void Flush()
        {
            LastKeyboardState = KeyboardState;
        }

        public static bool KeyReleased(Keys key)
        {
            return KeyboardState.IsKeyUp(key) && LastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return KeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return KeyboardState.IsKeyDown(key);
        }

        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonUp(button) &&
            LastGamePadStates[(int)index].IsButtonDown(button);
        }
        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonDown(button) &&
            LastGamePadStates[(int)index].IsButtonUp(button);
        }
        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonDown(button);
        }

    }
}
