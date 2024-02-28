import { createSlice, PayloadAction, createAsyncThunk, AnyAction } from '@reduxjs/toolkit';
import { AdditionalProdParams, DetailProductInfo, Product } from '../types';
import Api from '../../utils/api';
import { DetailProductInfoState } from '../types';
import { count } from 'console';


const initialState: DetailProductInfoState = {
    additionalProdParams: null,
    recommendedProducts: null,
    productInfo: null,
    loading: false,
    error: null
}

export const getDetailProductInfo = createAsyncThunk<DetailProductInfo, number, { rejectValue: string }>(
    'detailProduct/getDetailProductInfo',

    async function (id, { rejectWithValue }) {

        const response = await Api.getProductDetailInfoAsync(id);


        if (!response.data) {
            return rejectWithValue('Server Error!');
        }

        const data = await response.data;
        return data;

    }
);

export const getAdditionalParams = createAsyncThunk<AdditionalProdParams, number, { rejectValue: string }>(
    'detailProduct/getAdditionalParams',

    async function (id, { rejectWithValue }) {

        const response = await Api.getAdditionalParamsAsync(id);


        if (!response.data) {
            return rejectWithValue('Server Error!');
        }

        const data = await response.data;
        return data;

    }
);

export const getRecommendedProducts = createAsyncThunk<Product[], {id:number,count:number}, { rejectValue: string }>(
    'detailProduct/getRecommendedProducts',

    async function ({id,count}, { rejectWithValue }) {

        const response = await Api.getRecommendedProductsAsync(id,count);


        if (!response.data) {
            return rejectWithValue('Server Error!');
        }

        const data = await response.data;
        return data;

    }
);



const detailProductSlice = createSlice({
    name: 'detailProduct',
    initialState: initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder

            /*---------getDetailProductInfo---------*/

            .addCase(getDetailProductInfo.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(getDetailProductInfo.fulfilled, (state, action) => {
                state.productInfo = action.payload
                state.loading = false;
                state.error = null;

            })
            .addCase(getDetailProductInfo.rejected, (state, action) => {
                state.error = (action.payload) ? action.payload : "Error loading the products list";
                state.loading = false;
            })

            /*---------getAdditionalParams---------*/

            .addCase(getAdditionalParams.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(getAdditionalParams.fulfilled, (state, action) => {
                state.additionalProdParams = action.payload
                state.loading = false;
                state.error = null;

            })
            .addCase(getAdditionalParams.rejected, (state, action) => {
                state.error = (action.payload) ? action.payload : "Error loading the products list";
                state.loading = false;
            })

            /*----------getRecommendedProducts--------*/

            .addCase(getRecommendedProducts.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(getRecommendedProducts.fulfilled, (state, action) => {
                state.recommendedProducts = action.payload
                state.loading = false;
                state.error = null;

            })
            .addCase(getRecommendedProducts.rejected, (state, action) => {
                state.error = (action.payload) ? action.payload : "Error loading the products list";
                state.loading = false;
            })
    }
});

export default detailProductSlice.reducer;
