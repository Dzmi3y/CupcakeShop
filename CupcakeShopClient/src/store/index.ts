import { configureStore } from '@reduxjs/toolkit';
import bestsellerReducer from './reducers/bestsellerReducer';
import catalogReduser from './reducers/catalogReduser';

const store = configureStore({
  reducer: {
    bestsellerStore: bestsellerReducer,
    catalogStore: catalogReduser,
  },
});

export default store;

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;