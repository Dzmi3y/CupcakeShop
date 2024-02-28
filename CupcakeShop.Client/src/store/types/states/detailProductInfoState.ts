import { AdditionalProdParams } from "../additionalProdParams";
import { DetailProductInfo } from "../detailProductInfo";
import { Product } from "../product";

export type DetailProductInfoState={
    productInfo: DetailProductInfo | null;
    additionalProdParams:AdditionalProdParams | null;
    recommendedProducts:Product[] | null;
    loading: boolean;
    error: string | null;
}