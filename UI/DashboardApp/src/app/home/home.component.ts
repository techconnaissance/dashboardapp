import { Component } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';

import { User, Model, Commodity } from '../_models';
import { AccountService, DataService } from '../_services';

import { forkJoin, Observable } from 'rxjs';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    user: User;
    
    currentPosition: number = 0;
    valueAtRisk : number = 0;
    pnlYTD: number = 0;
    pnlLTD: number = 0;

    selectedModelId : any;
    selectedCommodityId : any;
    selectedYear : any;
    defaultYearList: any;
    defaultModelList: Model[];
    defaultCommodityList: Commodity[];

    pnlListingUrl: string;
    priceListingUrl: string;
    positionListingUrl: string;
    txnListingUrl: string;

    public lineChartData: ChartDataSets[] = [
        { data: [], label: 'Price' },
    ];
    public lineChartLabels: Label[] = [];//['January', 'February', 'March', 'April', 'May', 'June', 'July'];

    public lineChartOptions: (ChartOptions & { annotation: any }) = {
        responsive: true,
        annotation: []
    };
    public lineChartColors: Color[] = [
    {
        borderColor: 'black',
        backgroundColor: 'pink',
    },
    ];
    public lineChartLegend = true;
    public lineChartType = 'line';
    public lineChartPlugins = [];


    public lineChartPnlData: ChartDataSets[] = [
        { data: [], label: 'PnL' },
    ];
    public lineChartPnlLabels: Label[] = [];//['January', 'February', 'March', 'April', 'May', 'June', 'July'];

    public lineChartPnlOptions: (ChartOptions & { annotation: any }) = {
        responsive: true,
        annotation: []
    };
    public lineChartPnlColors: Color[] = [
    {
        borderColor: 'black',
        backgroundColor: '#22cde8',
    },
    ];
    public lineChartPnlLegend = true;
    public lineChartPnlType = 'line';
    public lineChartPnlPlugins = [];


    public lineChartPosData: ChartDataSets[] = [
        { data: [], label: 'PnL' },
    ];
    public lineChartPosLabels: Label[] = [];//['January', 'February', 'March', 'April', 'May', 'June', 'July'];

    public lineChartPosOptions: (ChartOptions & { annotation: any }) = {
        responsive: true,
        annotation: []
    };
    public lineChartPosColors: Color[] = [
        {
            borderColor: 'black',
            backgroundColor: '#78d8a3',
        },
    ];
    public lineChartPosLegend = true;
    public lineChartPosType = 'line';
    public lineChartPosPlugins = [];
    

    constructor(private accountService: AccountService, private dataService : DataService) {
        this.user = this.accountService.userValue;
    }

    ngOnInit() {
        this.loadDefaults();
    }

    loadDefaults()
    {
        this.dataService.getMasterData().subscribe(res => {
            this.defaultModelList = res.models;
            this.defaultCommodityList = res.commodities;
            this.defaultYearList = res.years;

            this.selectedModelId = this.defaultModelList[0].id;
            this.selectedCommodityId = this.defaultCommodityList[0].id;
            this.selectedYear = this.defaultYearList[0];

            this.constructUrl();
            
            this.populateFields();
        });
    }
    constructUrl(){
        //Todo: Remove - use calendar
        let fromDate = `${this.selectedYear}-01-01`;
        let toDate = `${this.selectedYear}-12-31`;

        this.pnlListingUrl = `/listing?module=pnl&commodityid=${this.selectedCommodityId}&modelid=${this.selectedModelId}&fromdate=${fromDate}&todate=${toDate}`;
        this.priceListingUrl = `/listing?module=price&commodityid=${this.selectedCommodityId}&modelid=${this.selectedModelId}&fromdate=${fromDate}&todate=${toDate}`;
        this.positionListingUrl = `/listing?module=position&commodityid=${this.selectedCommodityId}&modelid=${this.selectedModelId}&fromdate=${fromDate}&todate=${toDate}`;
        this.txnListingUrl = `/listing?module=transaction&commodityid=${this.selectedCommodityId}&modelid=${this.selectedModelId}&fromdate=${fromDate}&todate=${toDate}`;
    }
    refreshData() {
        this.constructUrl();
        this.populateFields();
    }

    populateFields() {

        //Calls to backend
        //Todo: Remove - use calendar
        let fromDate = `${this.selectedYear}-01-01`;
        let toDate = `${this.selectedYear}-12-31`;

        this.dataService.getPrice(this.selectedCommodityId, this.selectedModelId,fromDate,toDate ).subscribe(res => {
            //this.lineChartData = res.map(a => a.amount) as any[];
            this.lineChartData = [ { data : res.map(a => a.amount) as any[], label: 'Price'} ];
            this.lineChartLabels = res.map(a => a.dateStr) as any[];
        });

        this.dataService.getPosition(this.selectedCommodityId, this.selectedModelId,fromDate,toDate ).subscribe(res => {
            //this.lineChartData = res.map(a => a.amount) as any[];
            this.lineChartPnlData = [ { data : res.map(a => a.pnl) as any[], label: 'PNL'} ];
            this.lineChartPnlLabels = res.map(a => a.dateStr) as any[];

            this.lineChartPosData = [ { data : res.map(a => a.position) as any[], label: 'Positions'} ];
            this.lineChartPosLabels = res.map(a => a.dateStr) as any[];
        });

        this.dataService.getOtherMetrics(this.selectedCommodityId, this.selectedModelId,fromDate,toDate ).subscribe(res => {
            this.currentPosition = res.currentPosition;
            this.valueAtRisk = res.var;
            this.pnlYTD = res.pnLYTD;
            this.pnlLTD = res.pnLLTD;
        });
    }
}