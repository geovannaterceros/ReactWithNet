import { configureStore } from '@reduxjs/toolkit';
import { pokemonSlice } from './pokemon/pokemonSlice';
import { plateSlice } from './plate/plateSlice';
import { authSlice } from './auth/authSlice';

export const store = configureStore({
  reducer: {
    // pokemon: pokemonSlice.reducer,
    plate: plateSlice.reducer,
    auth: authSlice.reducer,
  },
  middleware: (getDefaultMiddleware: any) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;
