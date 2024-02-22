import { configureStore } from '@reduxjs/toolkit';
import bestsellerReducer from './reducers/bestsellerReducer';
import catalogReduser from './reducers/catalogReduser';
import detailProductReducer from './reducers/detailProductReducer';
import cartReducer from './reducers/cartReducer';

const store = configureStore({
  reducer: {
    bestsellerStore: bestsellerReducer,
    catalogStore: catalogReduser,
    detailProductStore: detailProductReducer,
    cartReducer:cartReducer
  },
});

export default store;

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;