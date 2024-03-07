import { Product } from "./product";

export interface DetailProductInfo extends  Product {
    imgUrlsJson: string,
    listOfshortDetails: string,
    description: string,
    storageConditions: string,
    delivery: string,
} 
