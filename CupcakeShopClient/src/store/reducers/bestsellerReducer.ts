import { createSlice, PayloadAction, createAsyncThunk, AnyAction } from '@reduxjs/toolkit';
import { Product, BestsellerState } from '../types'; 
import Api, { ProductTypesEnum } from '../../utils/api';


const initialState: BestsellerState = {
    list: [],
    loading: false,
    error: null,
}


export const getBestsellers = createAsyncThunk<Product[], undefined, { rejectValue: string }>(
    'bestsellers/getBestsellers',
    async function (_, { rejectWithValue }) {
        const response = await Api.getBestsellersAsync();

        if (!response.data) {
            return rejectWithValue('Server Error!');
        }

        const data = await response.data;
        return data;

    }
);



const bestsellerSlice = createSlice({
    name: 'bestsellers',
    initialState: initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase(getBestsellers.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(getBestsellers.fulfilled, (state, action) => {
                state.list = action.payload;
                state.loading = false;
                state.error = null;
            })
            .addCase(getBestsellers.rejected, (state, action) => {
                state.error = (action.payload) ? action.payload : "Error loading the bestseller list";
                state.loading = false;
            })
    }
});

export default bestsellerSlice.reducer;

