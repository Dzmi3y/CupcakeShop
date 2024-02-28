import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { CartItem, CartState } from "../types";



const saveCartToLocalStorage = (cart: CartItem[]) => {
    try {
        localStorage.setItem('cart', JSON.stringify(cart));
    } catch (e) {
        console.error(e);
    }
};

const loadCartFromLocalStorage = () => {
    try {
        const cartStr = localStorage.getItem('cart');
        const result: CartItem[] = cartStr ? JSON.parse(cartStr) : [];
        return result;
    } catch (e) {
        console.error(e);
        return [];
    }
};


const initialState: CartState = {
    cart: loadCartFromLocalStorage()
}

const cartSlice = createSlice({
    name: 'cart',
    initialState: initialState,
    reducers: {
        addProductToCart(state, action: PayloadAction<CartItem>) {
            const lastId = state.cart[state.cart.length - 1]?.id || 0;
            const newId = lastId + 1;
            const newCartItem = { ...action.payload, id: newId }
            state.cart.push(newCartItem);
            saveCartToLocalStorage(state.cart)
        },
        removeProductFromCart(state, action: PayloadAction<number>) {
            state.cart = state.cart.filter(cartItem => cartItem.id !== action.payload);
            saveCartToLocalStorage(state.cart)
        },
        clearCart(state) {
            state.cart = [];
            saveCartToLocalStorage(state.cart)
        }
    }
});





export const { addProductToCart, removeProductFromCart, clearCart } = cartSlice.actions
export default cartSlice.reducer;