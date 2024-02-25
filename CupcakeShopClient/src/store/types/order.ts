import { CartItem } from "./cartItem";

export type Order = {
    name?: string;
    phone?: string;
    email?: string;
    date?: string;
    deliveryMethod?: string;
    city?: string;
    street?: string;
    house?: string;
    entrance?: string;
    building?: string;
    apartment?: string;
    floor?: string;
    paymentMethod?: string;
    commentary?: string;
    cart?: CartItem[];
}