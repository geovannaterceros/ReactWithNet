import { useEffect, useState } from 'react';

export default function useForm<T>(initial: T = {} as T) {
  const [formState, setFormState] = useState(initial);

  const onInputChange = ({ target }: any) => {
    const { name, value } = target;
    setFormState({
      ...formState,
      [name]: value,
    });
  };

  const onResetForm = () => {
    setFormState({} as T);
  };

  return {
    ...formState,
    formState,
    onInputChange,
    onResetForm,
  };
}
