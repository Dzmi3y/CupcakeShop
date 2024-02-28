import { AdditionWeight } from "./additionWeight";
import { AdditionalProductParameter } from "./additionalProductParameter";
import { Product } from "./product";

export type CartItem = {
    id?: number,
    product: Product,
    additionWeight?: AdditionWeight,
    additionDecoration?: AdditionalProductParameter,
    additionSubspecies?: AdditionalProductParameter
}