import { loginWithEmailPassword, logoutFirebase, singInWithGoogle } from '~/firebase/provider';
import { InitialAuth, checkingCredentials, login, logout } from './authSlice';

export const startGoogleSignIn = () => {
  return async (dispatch: any) => {
    dispatch(checkingCredentials());
    const result = await singInWithGoogle();

    if (!result.ok) {
      return dispatch(
        logout({ initialAuth: { errorMessage: result.errorMessage } as InitialAuth }),
      );
    }

    const resultData: InitialAuth = {
      uid: result.uid,
      email: result.email,
      displayName: result.displayName,
      photoUrl: result.photoURL,
      errorMessage: result.errorMessage,
    };

    dispatch(login({ initialAuth: resultData }));
  };
};

export const startLoginWithEmailPassword = (email: string, password: string) => {
  return async (dispatch: any) => {
    dispatch(checkingCredentials());
    const result = await loginWithEmailPassword(email, password);
    if (!result.ok) {
      return dispatch(
        logout({ initialAuth: { errorMessage: result.errorMessage } as InitialAuth }),
      );
    }

    const resultData: InitialAuth = {
      uid: result.uid,
      displayName: result.displayName,
      photoUrl: result.photoURL,
      errorMessage: result.errorMessage,
    };

    dispatch(login({ initialAuth: resultData }));
  };
};

export const startLogout = () => {
  return async () => {
    await logoutFirebase();
    logout({ initialAuth: { errorMessage: '' } as InitialAuth });
  };
};
