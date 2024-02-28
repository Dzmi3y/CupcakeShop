import { createSlice, PayloadAction, createAsyncThunk, AnyAction } from '@reduxjs/toolkit';
import { Order } from '../types';
import Api from '../../utils/api';
import { OrderState } from '../types/states/orderStates';

const initialState: OrderState = {
    successMessage: "",
    loading: false,
    error: null
}

export const sendOrder = createAsyncThunk<any, Order, { rejectValue: string }>(
    'order/sendOrder',
    async function (order, { rejectWithValue }) {
        const response = await Api.postOrderAsync(order);
        if (!response.data) {
            return rejectWithValue('Server Error!');
        }
        const data = await response.data;
        return data;
    }
);

const orderSlice = createSlice({
    name: 'order',
    initialState: initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase(sendOrder.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(sendOrder.fulfilled, (state, action) => {
                state.successMessage = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(sendOrder.rejected, (state, action) => {
                state.error = (action.payload) ? action.payload : "Server error when placing an order";
                state.loading = false;
            })
    }
});

export default orderSlice.reducer;

