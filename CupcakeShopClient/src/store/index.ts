import { configureStore } from '@reduxjs/toolkit';
import bestsellerReducer from './reducers/bestsellerReducer';

const store = configureStore({
  reducer: {
    bestsellerStore: bestsellerReducer,
  },
});

export default store;

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;