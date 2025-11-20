import { RefObject, useEffect } from 'react';

const useOutsideClick = <T extends HTMLElement = HTMLElement>(
  ref: RefObject<T | null>,
  callback: () => void
) => {
  const handleClickOutside = (event: MouseEvent) => {
    if (ref.current && event.target instanceof Node && !ref.current.contains(event.target)) {
      callback();
    }
  };

  useEffect(() => {
    document.addEventListener('mousedown', handleClickOutside);
    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, [ref, callback]);
};

export default useOutsideClick;
