import { ProductTypesEnum } from "../enums/productTypesEnum";

export type PageInfo ={
    page: number;
    groupBy: number;
    typeId: ProductTypesEnum | undefined;

}