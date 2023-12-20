import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MarketDataService, CandleData } from './services/market-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  candleData: CandleData[] = [];
  constructor(private marketData: MarketDataService) {}

  ngOnInit() {
    this.marketData.getMarketData().subscribe(candles => {
      this.candleData = candles;
    });
  }
}
