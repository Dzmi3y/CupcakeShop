import { Product } from "./product";

export interface DetailProductInfo extends  Product {
    allImgUrls: string[],
    listOfshortDetails: string[],
    description: string,
    storageConditions: string,
    delivery: string,
} 
