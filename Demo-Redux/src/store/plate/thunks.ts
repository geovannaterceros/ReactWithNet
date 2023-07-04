import { AnyAction } from 'redux';
import { ThunkAction } from 'redux-thunk';
import { RootState } from '~/store';
import { deletePlate, getPlate, getPlateId, saveNewPlate, updatePlate } from './plateSlice';
import { plateApi } from '~/api/plateApi';
import { Plate } from '~/plate/modals/Plate.models';

export const ThunkGetPlate = (uid: string): ThunkAction<void, RootState, unknown, AnyAction> => {
  return async (dispatch) => {
    const { data } = await plateApi.get(`/Plates/?uid=` + uid);
    dispatch(
      getPlate({
        isLoading: false,
        plates: data,
      }),
    );
  };
};

export const ThunkPostPlate = (plate: Plate): ThunkAction<void, RootState, unknown, AnyAction> => {
  return async (dispatch) => {
    const { data } = await plateApi.post(`/Plates`, plate);
    dispatch(
      saveNewPlate({
        isLoading: false,
        plate: data,
      }),
    );
  };
};

export const ThunkDeletePlate = (id: any): ThunkAction<void, RootState, unknown, AnyAction> => {
  return async (dispatch) => {
    const { data } = await plateApi.delete(`/Plates/` + id);
    dispatch(
      deletePlate({
        isLoading: false,
        plate: data,
      }),
    );
  };
};

export const ThunkUpdatePlate = (
  id: any,
  plate: Plate,
): ThunkAction<void, RootState, unknown, AnyAction> => {
  return async (dispatch) => {
    const { data } = await plateApi.put(`/Plates/` + id, plate);
    dispatch(
      updatePlate({
        isLoading: true,
        plate: data,
      }),
    );
  };
};

export const ThunkGetPlateId = (id: any): ThunkAction<void, RootState, unknown, AnyAction> => {
  return async (dispatch) => {
    const { data } = await plateApi.get(`/Plates/` + id);
    dispatch(
      getPlateId({
        isLoading: false,
        plate: data,
      }),
    );
  };
};
