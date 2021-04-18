import { Component, OnInit } from '@angular/core';

import { User } from '../_models';
import { AccountService,DataService } from '../_services';

import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.scss']
})
export class ListingComponent implements OnInit {
  user: User;
  module: string;
  fromDate: string;
  toDate: string;
  commodityId: number;
  modelId: number;

  //configs
  priceColumnDefs = [
    { headerName: "Date", field: 'dateStr' , filter: 'agTextColumnFilter'},
    { field: 'price' , filter: 'agTextColumnFilter'},
    { field: 'commodityName', filter: 'agNumberColumnFilter'},
    { field: 'modelName', filter: 'agNumberColumnFilter'}
  ];

  pnlColumnDefs = [
    { headerName: "Date", field: 'dateStr' , filter: 'agTextColumnFilter'},
    { field: 'price' , filter: 'agNumberColumnFilter'},
    { field: 'commodityName', filter: 'agTextColumnFilter'},
    { field: 'modelName', filter: 'agTextColumnFilter'},
    { field: 'position', filter: 'agNumberColumnFilter'},
    { field: 'pnl', filter: 'agNumberColumnFilter'},
    { field: 'contract', filter: 'agTextColumnFilter'}
  ];

  positionColumnDefs = [
    { headerName: "Date", field: 'dateStr' , filter: 'agTextColumnFilter'},
    { field: 'commodityName', filter: 'agTextColumnFilter'},
    { field: 'modelName', filter: 'agTextColumnFilter'},
    { field: 'position', filter: 'agNumberColumnFilter'},
    { field: 'contract', filter: 'agTextColumnFilter'}
  ];

  txnColumnDefs = [
    { headerName: "Date", field: 'dateStr' , filter: 'agTextColumnFilter'},
    { field: 'transactionId', filter: 'agNumberColumnFilter'},
    { field: 'transactionQuantity', filter: 'agNumberColumnFilter'},
    { field: 'currentQuantity', filter: 'agNumberColumnFilter'},
    { field: 'price' , filter: 'agNumberColumnFilter'},
    { field: 'commodityName', filter: 'agTextColumnFilter'},
    { field: 'modelName', filter: 'agTextColumnFilter'},
    { field: 'commodityName', filter: 'agTextColumnFilter'},
    { field: 'createdBy', filter: 'agTextColumnFilter'}
  ];

  columnDefs = [  ];

  rowData = [ ];

  constructor(private accountService: AccountService, private route: ActivatedRoute, private dataService : DataService) {
    this.user = this.accountService.userValue;
  }

  ngOnInit(): void {
    this.getQueryParameter();

    this.loadData();
  }
  
  getQueryParameter() {
    this.route.queryParams.subscribe(params => {
      this.module = params['module'];
      this.modelId = params['modelid'];
      this.commodityId = params['commodityid'];
      this.fromDate = params["fromdate"];
      this.toDate = params["todate"];
    });
  }

  loadData() {
    if(this.module == "pnl"){
      this.columnDefs = this.pnlColumnDefs;
      this.dataService.getPosition(this.commodityId, this.modelId, this.fromDate, this.toDate).subscribe(res => {
        this.rowData = res;
      });
    }
    else if (this.module == "price"){
      this.columnDefs = this.priceColumnDefs;
      this.dataService.getPriceView(this.commodityId, this.modelId, this.fromDate, this.toDate).subscribe(res => {
        this.rowData = res;
      });
    }
    else if (this.module == "position"){
      this.columnDefs = this.positionColumnDefs;
      this.dataService.getPosition(this.commodityId, this.modelId, this.fromDate, this.toDate).subscribe(res => {
        this.rowData = res;
      });
    }
    else if (this.module == "transaction")
    {
      this.columnDefs = this.txnColumnDefs;
      this.dataService.getTransactionView(this.commodityId, this.modelId, this.fromDate, this.toDate).subscribe(res => {
        this.rowData = res;
      });
    }
  }


}
