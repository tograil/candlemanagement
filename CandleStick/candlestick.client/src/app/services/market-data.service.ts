import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MarketDataService {

  constructor(private httpClient:HttpClient) { }

  public getMarketData() : Observable<CandleData[]> {
    return this.httpClient.get<CandleData[]>('/market');
  } 
}

export interface CandleData {
  openPrice: number;
  closePrice: number;
  highPrice: number;
  lowPrice: number;
  dateTime: Date;
  quantity: number;
}
