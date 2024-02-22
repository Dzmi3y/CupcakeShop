import { Product } from "../product";

export type BestsellerState={
    list: Product[];
    loading: boolean;
    error: string | null;
}