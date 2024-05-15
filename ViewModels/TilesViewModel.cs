using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MVVM_Baraja.Models;
using ReactiveUI;

namespace MVVM_Baraja.ViewModels;

public class TilesViewModel: ViewModelBase
{   
    public ObservableCollection<Tile> TileList { get; set; } = new([
        new Tile(10, 10, 10),
        new Tile(10, 20, 20),
        new Tile(10, 30, 30)
    ]);
}