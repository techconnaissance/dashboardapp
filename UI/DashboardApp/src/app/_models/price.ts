export class Price {
    id: number;
    modelid: number;
    commodityid: number;
    amount: number;
    date: Date;
    dateStr: string;
}

export class DailyPosition {
    
    modelId: number;
    commodityId: number;
    pnl: number;
    date: Date;
    dateStr: string;
    position: number;
    contract: string;
    commodityName: string;
    modelName: string;
}

export class PriceView {
    
    modelId: number;
    commodityId: number;
    date: Date;
    dateStr: string;
    commodityName: string;
    modelName: string;
}

export class Metrics {
    currentPosition : number ;
    var : number ;
    pnLYTD : number;
    pnLLTD: number ;
}

export class TransactionView {
    
    modelId: number;
    commodityId: number;
    date: Date;
    dateStr: string;
    commodityName: string;
    modelName: string;
    contractName: string;
    transactionQuantity: number;
    currentQuantity: number;
    createdBy: string;
}
