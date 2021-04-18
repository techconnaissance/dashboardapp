import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { Commodity, Model, User, Price, DailyPosition,Metrics,PriceView, MasterData, TransactionView } from '../_models';

@Injectable({ providedIn: 'root' })
export class DataService {

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        
    }

    getmodels(term: string = null): Observable<Model[]> {
        return this.http.get<Model[]>(`${environment.backendApiUrl}/Models`);
    }

    getcommodity(term: string = null): Observable<Commodity[]> {
        
        return this.http.get<Commodity[]>(`${environment.backendApiUrl}/Commodities`);
    }

    getPrice(commodityId:number, modelid:number, fromDate: string, toDate: string): Observable<Price[]> {
        return this.http.get<Price[]>(`${environment.backendApiUrl}/price?commodityId=${commodityId}&modelId=${modelid}&fromDate=${fromDate}&toDate=${toDate}`);
    }

    getPosition(commodityId:number, modelid:number, fromDate: string, toDate: string): Observable<DailyPosition[]> {
        return this.http.get<DailyPosition[]>(`${environment.backendApiUrl}/position?commodityId=${commodityId}&modelId=${modelid}&fromDate=${fromDate}&toDate=${toDate}`);
    }

    getYears(): Observable<any> {
        return this.http.get<any>(`${environment.backendApiUrl}/year`);
    }

    getOtherMetrics(commodityId:number, modelid:number, fromDate: string, toDate: string): Observable<Metrics> {
        return this.http.get<Metrics>(`${environment.backendApiUrl}/metrics?commodityId=${commodityId}&modelId=${modelid}&fromDate=${fromDate}&toDate=${toDate}`);
    }

    getPriceView(commodityId:number, modelid:number, fromDate: string, toDate: string): Observable<PriceView[]> {
        return this.http.get<PriceView[]>(`${environment.backendApiUrl}/priceView?commodityId=${commodityId}&modelId=${modelid}&fromDate=${fromDate}&toDate=${toDate}`);
    }

    getTransactionView(commodityId:number, modelid:number, fromDate: string, toDate: string): Observable<TransactionView[]> {
        return this.http.get<TransactionView[]>(`${environment.backendApiUrl}/transactions?commodityId=${commodityId}&modelId=${modelid}&fromDate=${fromDate}&toDate=${toDate}`);
    }

    getMasterData(): Observable<MasterData> {
        return this.http.get<MasterData>(`${environment.backendApiUrl}/masterdata`);
    }
}