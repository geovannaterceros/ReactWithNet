import { createSlice } from '@reduxjs/toolkit';
import type { PayloadAction } from '@reduxjs/toolkit';

export interface InitialAuth {
  uid: string | undefined;
  email?: string | null | undefined;
  displayName: string | null | undefined;
  photoUrl: string | null | undefined;
  errorMessage?: string | undefined;
}

interface AuthState {
  status?: string;
  initialAuth: InitialAuth;
}

const initialState: AuthState = {
  status: 'checking',
  initialAuth: {
    uid: '',
    email: null,
    displayName: null,
    photoUrl: '',
    errorMessage: '',
  },
};

export const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    login: (state, action: PayloadAction<AuthState>) => {
      state.status = 'authenticated';
      state.initialAuth.uid = action.payload.initialAuth.uid;
      state.initialAuth.email = action.payload.initialAuth.email;
      state.initialAuth.displayName = action.payload.initialAuth.displayName;
      state.initialAuth.photoUrl = action.payload.initialAuth.photoUrl;
      state.initialAuth.errorMessage = action.payload.initialAuth.errorMessage;
    },
    logout: (state, action: PayloadAction<AuthState>) => {
      state.status = 'not-authenticated';
      state.initialAuth.uid = '';
      state.initialAuth.email = '';
      state.initialAuth.displayName = '';
      state.initialAuth.photoUrl = '';
      state.initialAuth.errorMessage = action.payload.initialAuth.errorMessage;
    },
    checkingCredentials: (state) => {
      state.status = 'checking';
    },
  },
});

// Action creators are generated for each case reducer function
export const { login, logout, checkingCredentials } = authSlice.actions;

export default authSlice.reducer;
