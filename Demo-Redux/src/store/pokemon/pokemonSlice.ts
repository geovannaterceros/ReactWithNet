import { createSlice } from '@reduxjs/toolkit';
import type { PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '~/store';

export interface PokemonState {
  isLoading: boolean;
  pokemon: [];
  page: number;
}

const initialState: PokemonState = {
  isLoading: false,
  pokemon: [],
  page: 0,
};

export const pokemonSlice = createSlice({
  name: 'pokemon',
  initialState,
  reducers: {
    loadPagePokemon: (state) => {
      state.isLoading = true;
    },
    getPokemon: (state, action: PayloadAction<PokemonState>) => {
      state.isLoading = action.payload.isLoading;
      state.page = action.payload.page;
      state.pokemon = action.payload.pokemon;
    },
  },
});

// Action creators are generated for each case reducer function
export const { getPokemon, loadPagePokemon } = pokemonSlice.actions;

export const selectCount = (state: RootState) => state.pokemon;

export default pokemonSlice.reducer;
