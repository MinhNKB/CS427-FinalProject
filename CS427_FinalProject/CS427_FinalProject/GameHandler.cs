using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS427_FinalProject
{
    public class GameHandler : VisibleGameEntity
    {
        Dictionary<ViewState, ViewHandler> viewHandlers;
        public GameHandler()
        {
            viewHandlers = new Dictionary<ViewState, ViewHandler>();

            viewHandlers.Add(ViewState.GameView, new GameViewHandler());
            viewHandlers.Add(ViewState.MainMenuView, new MainMenuViewHandler());
            viewHandlers.Add(ViewState.NewGameView, new NewGameViewHandler());
            viewHandlers.Add(ViewState.SettingView, new SettingView());
            viewHandlers.Add(ViewState.PausedView, new PauseView());
            viewHandlers.Add(ViewState.GameOverView, new GameOverView());

            (viewHandlers[ViewState.NewGameView] as NewGameViewHandler).AcceptBtn_Click += GameHandler_AcceptBtn_Click;
            //viewHandlers.Add(ViewState.MenuView, new MenuViewHandler());
        }

        void GameHandler_AcceptBtn_Click(object sender, EventArgs e)
        {
            viewHandlers[ViewState.GameView] = new GameViewHandler();
            Global.gViewState = ViewState.GameView;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            viewHandlers[Global.gViewState].Update(gameTime);
        }

        public override void Draw(GameTime gameTime, object param)
        {
            base.Draw(gameTime, param);
            viewHandlers[Global.gViewState].Draw(gameTime, param);
        }
        
    }
}
