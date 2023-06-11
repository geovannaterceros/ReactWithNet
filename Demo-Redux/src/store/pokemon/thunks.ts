import { AnyAction } from 'redux';
import { ThunkAction } from 'redux-thunk';
import { getPokemon, loadPagePokemon } from './pokemonSlice';
import { RootState } from '~/store';
import { pokemonApi } from '~/api/pokemonApi';

export const ThunkGetPokemon = (page = 0): ThunkAction<void, RootState, unknown, AnyAction> => {
  return async (dispatch) => {
    dispatch(loadPagePokemon());
    const asyncResp = await exampleAPI(page);
    dispatch(
      getPokemon({
        isLoading: false,
        pokemon: asyncResp.results,
        page: page + 1,
      }),
    );
  };
};

async function exampleAPI(page: number) {
  // const resp = fetch(`/pokemon?limit=10&offset=${1 * 10}`);
  // const data = await (await resp).json();
  const { data } = await pokemonApi.get(`/pokemon?limit=10&offset=${page * 10}`);
  return data;
}
