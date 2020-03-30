﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GalacticImperialism
{
    class AudioSettings
    {
        string titleText;

        SpriteFont fontOfButtons;
        SpriteFont fontOfTitle;

        GraphicsDevice GraphicsDevice;

        Slider masterVolumeSlider;
        Slider musicVolumeSlider;
        Slider soundEffectsVolumeSlider;

        Texture2D sliderBackgroundTexture;
        Texture2D sliderCursorTexture;

        public float masterVolume;
        public float musicVolume;
        public float soundEffectsVolume;

        public AudioSettings(SpriteFont buttonFont, SpriteFont titleFont, Texture2D sliderBackgroundTexture, Texture2D sliderCursorTexture, GraphicsDevice GraphicsDevice)
        {
            fontOfButtons = buttonFont;
            fontOfTitle = titleFont;
            this.sliderBackgroundTexture = sliderBackgroundTexture;
            this.sliderCursorTexture = sliderCursorTexture;
            this.GraphicsDevice = GraphicsDevice;
            Initialize();
        }

        public void Initialize()
        {
            titleText = "Audio Settings";
            masterVolumeSlider = new Slider(new Rectangle(900, 325, 500, 20), new Vector2(15, 30), sliderBackgroundTexture, sliderCursorTexture);
            musicVolumeSlider = new Slider(new Rectangle(900, 425, 500, 20), new Vector2(15, 30), sliderBackgroundTexture, sliderCursorTexture);
            soundEffectsVolumeSlider = new Slider(new Rectangle(900, 525, 500, 20), new Vector2(15, 30), sliderBackgroundTexture, sliderCursorTexture);
            masterVolume = 1.0f;
            musicVolume = 1.0f;
            soundEffectsVolume = 1.0f;
        }

        public void Update(KeyboardState kb, KeyboardState oldKb, MouseState mouse, MouseState oldMouse)
        {
            masterVolumeSlider.Update(mouse, oldMouse);
            masterVolume = masterVolumeSlider.percentage;
            musicVolumeSlider.Update(mouse, oldMouse);
            musicVolume = musicVolumeSlider.percentage;
            soundEffectsVolumeSlider.Update(mouse, oldMouse);
            soundEffectsVolume = soundEffectsVolumeSlider.percentage;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 textSize = fontOfTitle.MeasureString(titleText);
            spriteBatch.DrawString(fontOfTitle, titleText, new Vector2((GraphicsDevice.Viewport.Width / 2) - (textSize.X / 2), (GraphicsDevice.Viewport.Height / 6) - (textSize.Y / 2)), Color.White);
            textSize = fontOfButtons.MeasureString("Press Escape To Return To Settings");
            spriteBatch.DrawString(fontOfButtons, "Press Escape To Return To Settings", new Vector2((GraphicsDevice.Viewport.Width / 2) - (textSize.X / 2), GraphicsDevice.Viewport.Height - textSize.Y), Color.White);
            masterVolumeSlider.Draw(spriteBatch);
            spriteBatch.DrawString(fontOfButtons, "Master Volume:", new Vector2(450, 318), Color.White);
            spriteBatch.DrawString(fontOfButtons, masterVolume * 100 + "%", new Vector2(1450, 318), Color.White);
            musicVolumeSlider.Draw(spriteBatch);
            spriteBatch.DrawString(fontOfButtons, "Music Volume:", new Vector2(450, 418), Color.White);
            spriteBatch.DrawString(fontOfButtons, musicVolume * 100 + "%", new Vector2(1450, 418), Color.White);
            soundEffectsVolumeSlider.Draw(spriteBatch);
            spriteBatch.DrawString(fontOfButtons, "Sound Effects Volume:", new Vector2(450, 518), Color.White);
            spriteBatch.DrawString(fontOfButtons, soundEffectsVolume * 100 + "%", new Vector2(1450, 518), Color.White);
        }
    }
}