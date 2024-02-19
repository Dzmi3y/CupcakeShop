import { Product } from "./product"

export type CatalogApiResult =
    {
        list: Product[],
        totalPagesNumber: number
    }