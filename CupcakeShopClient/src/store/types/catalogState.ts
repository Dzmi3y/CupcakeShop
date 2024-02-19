import { Product } from "./product";

export type CatalogState = {
    list: Product[];
    loading: boolean;
    error: string | null;
    totalPagesNumber: number | null;
}