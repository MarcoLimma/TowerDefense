using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense.Lib.Input
{
    public enum AttackInputMode
    {
        MouseAttack,
        KeyAttack
    }

    public class InputConfiguration
    {
        private static InputConfiguration config;

        public InputConfiguration()
        {
            Up = Keys.W;
            Down = Keys.S;
            Left = Keys.A;
            Right = Keys.D;
            DoubleClickDelay = 400;
            Inventory = Keys.I;
            QuestLog = Keys.L;
            CharacterInformation = Keys.C;
            Hotkeys = new Dictionary<int, Keys>();
            Hotkeys.Add(0, Keys.Q);
            Hotkeys.Add(1, Keys.E);
            Hotkeys.Add(2, Keys.F);
            Hotkeys.Add(3, Keys.D4);
            Hotkeys.Add(4, Keys.D5);
            Hotkeys.Add(5, Keys.D6);
            Hotkeys.Add(6, Keys.D7);
            Hotkeys.Add(7, Keys.D8);
            Hotkeys.Add(8, Keys.D9);
            Hotkeys.Add(9, Keys.D0);
        }

        public static InputConfiguration Config
        {
            get
            {
                if (config == null) config = new InputConfiguration();
                return config;
            }
            set { config = value; }
        }

        // Action Keys
        public Keys Up { get; set; }
        public Keys Down { get; set; }
        public Keys Left { get; set; }
        public Keys Right { get; set; }
        public Keys Inventory { get; set; }
        public Keys QuestLog { get; set; }
        public Keys CharacterInformation { get; set; }

        [XmlIgnore]
        public Dictionary<int, Keys> Hotkeys { get; set; }

        public int DoubleClickDelay { get; set; }

        public static void Save()
        {
            //Serializer<InputConfiguration>.SerializeObject(Config, "Config/keyboardConfig.xml");
        }

        public static void Load()
        {
            //Config = Serializer<InputConfiguration>.DeserializeObject("Config/keyboardConfig.xml");
        }
    }
}