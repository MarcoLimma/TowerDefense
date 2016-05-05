using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.Lib.Graphics
{
    public static class GameGraphics
    {
        public static Texture2D SelectedItemTexture { get; set; }

        #region Scene backgrounds
        
        public static Texture2D MainMenu { get; set; }

        #endregion

        #region GameObjects Sprites

        public static Texture2D SimpleTower { get; set; }

        public static Texture2D Range { get; set; }

        #endregion

        #region Buttons 

        public static Texture2D CharacterHpBar { get; set; }
        public static Texture2D CharacterHpBarBg { get; set; }

        #endregion

        #region Etc
        public static Texture2D MouseClick { get; set; }
        public static Texture2D TargetCircle { get; set; }
        public static Texture2D BigCircle { get; set; }
        public static Texture2D CloseButton { get; set; }
        public static Texture2D Button { get; set; }
        public static Texture2D ButtonHover { get; set; }
        public static Texture2D GameOver { get; set; }
        public static Texture2D BlankBarBackground { get; set; }
        public static Texture2D BlankBar { get; set; }
        public static Texture2D ButtonPressed { get; set; }
        public static Texture2D GamePaused { get; set; }
        public static Texture2D HelpMenu { get; set; }
        public static Texture2D GameStatsHelpMenu { get; set; }
        public static Texture2D EmptyTransition { get; set; }

        public static Color DialogTextColor { get; set; }
        public static Color SelectedOptionColor { get; set; }

        public static Texture2D CollisionRadius { get; set; }
        public static Texture2D SpaceTextures { get; set; }
        public static Texture2D SpaceTextures2 { get; set; }
        public static Texture2D SpaceTextures3 { get; set; }
        public static Texture2D Ship1 { get; set; }
        public static Texture2D Explosion1 { get; set; }
        public static Texture2D BigShip1 { get; set; }
        public static Texture2D Star1 { get; internal set; }
        public static Texture2D MonsterSpriteIdle { get; set; }
        public static Texture2D HealthKit { get; set; }
        public static Texture2D MonsterTrack { get; set; }
        public static Texture2D Planet1 { get; set; }

        public static Texture2D Menu1 { get; set; }
        public static Texture2D Menu2 { get; set; }
        public static SoundEffect SoundExplosion { get; internal set; }
        public static SoundEffect SoundExplosionBig { get; set; }
        public static SoundEffect SoundHeal { get; set; }
        public static Texture2D MonsterSpriteAttack { get; internal set; }
        public static Texture2D GameOverMenu1 { get; set; }
        public static Texture2D GameOverMenu2 { get; set; }
        public static Texture2D Ship2 { get; set; }
        public static SoundEffect SoundSelect { get; set; }
        #endregion

        public static void Load(ContentManager content)
        {
            //EmptyTransition = content.Load<Texture2D>("Images/black10px");
            //Button = content.Load<Texture2D>("Images/Button");
            //ButtonHover = content.Load<Texture2D>("Images/Button_hover");
            //ButtonPressed = content.Load<Texture2D>("Images/Button_pressed");
            //SelectedItemTexture = content.Load<Texture2D>("Textures/selectedItemTexture");

            MainMenu = content.Load<Texture2D>("Scene Backgrounds/Main Menu Background");

            SimpleTower = content.Load<Texture2D>("Objects/Simple Tower");

            Range = content.Load<Texture2D>("Objects/Range");

            //CollisionRadius = content.Load<Texture2D>("Circle 400px");
        }
    }
}