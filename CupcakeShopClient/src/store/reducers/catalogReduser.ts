import { createSlice, PayloadAction, createAsyncThunk, AnyAction } from '@reduxjs/toolkit';
import { Product, CatalogState, PageInfo, CatalogApiResult } from '../types';
import Api from '../../utils/api';


const initialState: CatalogState = {
    list: [],
    loading: false,
    error: null,
    totalPagesNumber: null,
}



export const getProductList = createAsyncThunk<CatalogApiResult, PageInfo, { rejectValue: string }>(
    'catalog/getProductList',

    async function (pageInfo, { rejectWithValue }) {

        const response = await Api.getCatalogAsync(pageInfo.page, pageInfo.typeId, pageInfo.groupBy);


        if (!response.data) {
            return rejectWithValue('Server Error!');
        }

        const data = await response.data;
        return { ...data, currentPage: pageInfo.page };

    }
);



const catalogSlice = createSlice({
    name: 'catalog',
    initialState: initialState,
    reducers: {

    },
    extraReducers: (builder) => {
        builder
            .addCase(getProductList.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(getProductList.fulfilled, (state, action) => {
                state.list = action.payload.list;
                state.totalPagesNumber = action.payload.totalPagesNumber;
                state.loading = false;
                state.error = null;

            })
            .addCase(getProductList.rejected, (state, action) => {
                state.error = (action.payload) ? action.payload : "Error loading the products list";
                state.loading = false;
            })
    }
});

export default catalogSlice.reducer;