import { createSlice } from '@reduxjs/toolkit';
import type { PayloadAction } from '@reduxjs/toolkit';
import { Plate } from '~/plate/modals/Plate.models';

interface PlateState {
  isLoading: boolean;
  plates?: Plate[];
  plate?: Plate | null;
}

const initialState: PlateState = {
  isLoading: false,
  plates: [],
  plate: null,
};

export const plateSlice = createSlice({
  name: 'plate',
  initialState,
  reducers: {
    getPlate: (state, action: PayloadAction<PlateState>) => {
      state.isLoading = false;
      state.plates = action.payload.plates;
    },
    getPlateId: (state, action: PayloadAction<PlateState>) => {
      state.isLoading = false;
      state.plate = action.payload.plate;
    },
    saveNewPlate: (state, action: PayloadAction<PlateState>) => {
      state.isLoading = false;
      state.plate = action.payload.plate;
    },
    deletePlate: (state, action: PayloadAction<PlateState>) => {
      state.isLoading = false;
      state.plate = action.payload.plate;
    },
    updatePlate: (state, action: PayloadAction<PlateState>) => {
      state.isLoading = action.payload.isLoading;
      state.plate = action.payload.plate;
    },
  },
});

export const { getPlate, getPlateId, saveNewPlate, deletePlate, updatePlate } = plateSlice.actions;

export default plateSlice.reducer;
