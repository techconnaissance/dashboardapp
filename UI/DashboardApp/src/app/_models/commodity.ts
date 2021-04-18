

export class Commodity {
    id: number;
    name: string;
}


export class Model {
    id: number;
    name: string;
}

export class MasterData {
    commodities: Commodity[];
    models: Model[];
    years: number[];
}