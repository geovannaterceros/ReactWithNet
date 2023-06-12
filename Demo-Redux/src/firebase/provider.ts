import {
  GoogleAuthProvider,
  signInWithEmailAndPassword,
  signInWithPopup,
  updateProfile,
} from 'firebase/auth';
import { FirebaseAuth } from './config';

const googleProvider = new GoogleAuthProvider();

export const singInWithGoogle = async () => {
  try {
    const result = await signInWithPopup(FirebaseAuth, googleProvider);
    // const credentials = GoogleAuthProvider.credentialFromResult(result);
    //console.log('credential', credentials);
    const { displayName, email, photoURL, uid } = result.user;

    return {
      ok: true,
      displayName,
      email,
      photoURL,
      uid,
    };
  } catch (error: any) {
    const errorMessage = error.message;

    return {
      ok: false,
      errorMessage,
    };
  }
};

export const loginWithEmailPassword = async (email: string, password: string) => {
  try {
    const result = await signInWithEmailAndPassword(FirebaseAuth, email, password);
    const { displayName, photoURL, uid } = result.user;

    return {
      ok: true,
      displayName,
      photoURL,
      uid,
    };
  } catch (error: any) {
    const errorMessage = error.message;

    return {
      ok: false,
      errorMessage,
    };
  }
};

export const updateUser = async (displayName: string) => {
  try {
    //const result = await signInWithEmailAndPassword(FirebaseAuth, email, password);
    // const resp = await createUserWithEmailAndPassword(FirebaseAuth, email, password);
    // const { uid, photoURL } = resp.user;
    const currentUser = FirebaseAuth.currentUser;
    console.log(currentUser);
    if (currentUser !== null) {
      const result = await updateProfile(currentUser, { displayName });
      console.log(result);
    }

    return {
      ok: true,
      displayName,
    };
  } catch (error) {
    console.log(error);
    return { ok: false, errorMessage: 'Error' };
  }
};

export const logoutFirebase = async () => {
  return await FirebaseAuth.signOut();
};
