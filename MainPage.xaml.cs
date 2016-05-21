using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TresEnRaya
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SolidColorBrush playerColor = new SolidColorBrush(Windows.UI.Colors.Green);
        SolidColorBrush enemyColor = new SolidColorBrush(Windows.UI.Colors.Red);
        Board gameBoard;
        AI enemy;


        public MainPage()
        {
            gameBoard= new Board();
            enemy = new AI(gameBoard);
            this.InitializeComponent();
        }

        private async void Rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (((Windows.UI.Xaml.Shapes.Rectangle)sender).Fill == playerColor)
            {
                var error = new Windows.UI.Popups.MessageDialog("Ya tienes una ficha en esa casilla");
                await error.ShowAsync();
            }
            else if (((Windows.UI.Xaml.Shapes.Rectangle)sender).Fill == enemyColor)
            {
                var error = new Windows.UI.Popups.MessageDialog("El enemigo ya tiene una ficha en esa casilla");
                await error.ShowAsync();
            }
            else
            {
                ((Windows.UI.Xaml.Shapes.Rectangle)sender).Fill = playerColor;
                gameBoard.setTile(((Windows.UI.Xaml.Shapes.Rectangle)sender).Name, Board.TileStates.Player);
                if (gameBoard.evaluateBoard() == Board.TileStates.Player)
                {
                    var notification = new Windows.UI.Popups.MessageDialog("Has ganado!");
                    await notification.ShowAsync();
                    gameBoard.clear();
                    clearBoard();
                }
                else
                {
                    enemyTurn();
                }
            }
        }

        private async void enemyTurn()
        {
            string nextMove = enemy.nextMove();
            try
            {
                gameBoard.setTile(nextMove, Board.TileStates.Enemy);
            }catch(TileOccupiedException e)
            {
                var notification = new Windows.UI.Popups.MessageDialog("Empate, tablero lleno");
                await notification.ShowAsync();
                gameBoard.clear();
                clearBoard();
                return;
            }
            Windows.UI.Xaml.Shapes.Rectangle nextTile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName(nextMove);
            nextTile.Fill = enemyColor;
            if (gameBoard.evaluateBoard() == Board.TileStates.Enemy)
            {
                var notification = new Windows.UI.Popups.MessageDialog("Has perdido!");
                await notification.ShowAsync();
                gameBoard.clear();
                clearBoard();
            }
        }

        private void clearBoard()
        {
            Windows.UI.Xaml.Shapes.Rectangle tile;

            tile= (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_0");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentMediumBrush"];
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_1");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentLowBrush"];
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c0_2");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentMediumBrush"];

            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_0");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentLowBrush"];
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_1");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentMediumBrush"];
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c1_2");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentLowBrush"];

            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_0");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentMediumBrush"];
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_1");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentLowBrush"];
            tile = (Windows.UI.Xaml.Shapes.Rectangle)this.FindName("c2_2");
            tile.Fill = (Windows.UI.Xaml.Media.Brush)Application.Current.Resources["SystemControlHighlightListAccentMediumBrush"];
        }
    }
}
