// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace Ghis.Controls.Test.Carousels;

using Ghis.Controls.Test.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

internal class CarouselViewModel : BindableBase
{
    private ObservableCollection<CarouselData> items = new ObservableCollection<CarouselData>();
    private CarouselData selectedItem;
    public ObservableCollection<CarouselData> Items
    {
        get => this.items;
        set => this.SetProperty<ObservableCollection<CarouselData>>(ref this.items, value);

    }
    public CarouselData SelectedItem
    {
        get => this.selectedItem;
        set => this.SetProperty<CarouselData>(ref this.selectedItem, value);
    }
    public CarouselViewModel()
    {
        this.Items.Add(new CarouselData() { Name = "BBC Radio 1", ShortName = "BBC R1", ImageSource = "/images/Carousels/BBCRadio1.jpg", Text = "Clara Amfo: Christine and the Queens are in the Live Lounge!" });
        this.Items.Add(new CarouselData() { Name = "BBC Radio 1 Extra", ShortName = "BBC R1 Extra", ImageSource = "/images/Carousels/BBCRadio1Extra.jpg", Text = "Ace: Swedish-Gambian R&B singer Seinabo Say." });
        this.Items.Add(new CarouselData() { Name = "BBC Radio 2", ShortName = "BBC R2", ImageSource = "/images/Carousels/BBCRadio2.jpg", Text = "Ken Bruce: Roger Daltrey chooses the Tracks of My Years." });
        this.Items.Add(new CarouselData() { Name = "BBC Radio 3", ShortName = "BBC R3", ImageSource = "/images/Carousels/BBCRadio3.jpg", Text = "The London Philharmonic play Motorhead." });
        this.Items.Add(new CarouselData() { Name = "BBC Radio 4", ShortName = "BBC R4", ImageSource = "/images/Carousels/BBCRadio4.jpg", Text = "Melvin Bragg talks to some clever people." });
        this.Items.Add(new CarouselData() { Name = "BBC Radio 4 Extra", ShortName = "BBC R4 Extra", ImageSource = "/images/Carousels/BBCRadio4Extra.jpg", Text = "Around the Horne." });
        this.Items.Add(new CarouselData() { Name = "BBC Radio 5 Live", ShortName = "BBC R5 Live", ImageSource = "/images/Carousels/BBCRadio5Live.jpg", Text = "The Emma Barnett Show: cutting edge political debate." });
        this.Items.Add(new CarouselData() { Name = "BBC Radio 5 Live Sports", ShortName = "BBC R5 Live Sports", ImageSource = "/images/Carousels/BBCRadio5LiveSports.jpg", Text = "Football chat with Steve Crossman and guests Leon Osman and Simon Grayson." });
        this.Items.Add(new CarouselData() { Name = "BBC Radio 6 Music", ShortName = "BBC R6 Music", ImageSource = "/images/Carousels/BBCRadio6Music.jpg", Text = "Some music. What did you expect?" });
        this.Items.Add(new CarouselData() { Name = "BBC Radio Asian Network", ShortName = "BBC R Asian", ImageSource = "/images/Carousels/BBCRadioAsianNetwork.jpg", Text = "Noreen Khan: Nadia Ali sits in." });
        this.Items.Add(new CarouselData() { Name = "Heart", ShortName = "Heart", ImageSource = "/images/Carousels/Heart.png", Text = "Push the Button by Sugababes" });
        this.Items.Add(new CarouselData() { Name = "Jazz FM", ShortName = "Jazz FM", ImageSource = "/images/Carousels/JazzFM.jpg", Text = "Kenneth Clarke presents A History Of Jazz" });
        this.Items.Add(new CarouselData() { Name = "Capital FM", ShortName = "Capital FM", ImageSource = "/images/Carousels/CapitalFM.png", Text = "Bassman: Hear all the hottest tunes and freshest music news with The Bassman" });
    }
}