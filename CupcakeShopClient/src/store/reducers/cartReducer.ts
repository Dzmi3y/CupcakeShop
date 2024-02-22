import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { CartItem, CartState } from "../types";


const initialState: CartState = {
    cart: []
}

const cartSlice = createSlice({
    name: 'cart',
    initialState: initialState,
    reducers: {
        addProductToCart(state, action: PayloadAction<CartItem>) {
            const lastId = state.cart[state.cart.length - 1]?.id || 0;
            const newId = lastId + 1;
            state.cart.push({ ...action.payload, id: newId });
        },
        removeProductFromCart(state, action: PayloadAction<number>) {
            state.cart = state.cart.filter(cartItem => cartItem.id !== action.payload);
        }
    }
});


export const { addProductToCart, removeProductFromCart} = cartSlice.actions
export default cartSlice.reducer;