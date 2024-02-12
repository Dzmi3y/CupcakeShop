import { Bestseller } from "./bestseller";

export type BestsellerState={
    list: Bestseller[];
    loading: boolean;
    error: string | null;
}