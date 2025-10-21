'use client';

import { useRouter } from 'next/navigation';
import { type FC, useRef, useState, type MouseEvent, type FormEvent } from 'react';
import IconSearch from '@/components/icons/IconSearch';
import {
  pageUrls,
  SEARCH_SORT_BY_DEFAULT,
  SEARCH_SORT_DIRECTION_DEFAULT,
  SEARCH_START_INDEX_DEFAULT,
} from '@/shared/constants';

const SearchBar: FC = () => {
  const inputRef = useRef<HTMLInputElement>(null);
  const formRef = useRef<HTMLFormElement>(null);
  const [isFocused, setIsFocused] = useState(false);
  const router = useRouter();

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();

    if (inputRef.current?.value.trim()) {
      router.push(
        pageUrls.HOME_(
          encodeURIComponent(inputRef.current.value.trim()),
          SEARCH_START_INDEX_DEFAULT,
          SEARCH_SORT_BY_DEFAULT,
          SEARCH_SORT_DIRECTION_DEFAULT
        )
      );

      inputRef.current.value = '';
    }
    setIsFocused(false);
    inputRef.current?.blur();
  };

  const handleButtonClick = (e: MouseEvent<HTMLButtonElement>) => {
    if (!isFocused) {
      e.preventDefault();
      inputRef.current?.focus();
      return;
    }

    formRef.current?.requestSubmit();
    (e.target as HTMLButtonElement).blur();
  };

  const handleInputBlur = (e: React.FocusEvent<HTMLInputElement>) => {
    if (!e.relatedTarget || (e.relatedTarget as HTMLElement).tagName !== 'BUTTON')
      setIsFocused(false);
  };

  return (
    <form ref={formRef} onSubmit={handleSubmit} aria-label="Home Search Form">
      <div
        className={`transition-[grid-template-columns,box-shadow] duration-300 grid items-center justify-between gap-2 p-2 ps-4 text-sm bg-foreground border-accent rounded-4xl ring-2 ${isFocused ? 'ring-accent grid-cols-[auto_1fr_auto]' : 'ring-transparent grid-cols-[auto_0fr_auto]'}`}
      >
        <label
          htmlFor="home-search"
          className={`transition-colors ${isFocused ? 'text-accent-contrast' : 'text-gray-500'}`}
          aria-label="Home Search Bar Label"
        >
          <IconSearch width={24} height={24} aria-hidden="true" focusable="false" />
        </label>
        <input
          ref={inputRef}
          type="search"
          id="home-search"
          className={`font-medium transition-colors delay-300 focus:ring-0 focus:outline-none bg-transparent w-full ${isFocused ? 'placeholder:text-gray-500 text-accent-contrast' : 'placeholder:text-transparent text-transparent'}`}
          name="home-search"
          placeholder="Search ASCII..."
          autoComplete="off"
          aria-labelledby="home-search-description"
          onFocus={() => setIsFocused(true)}
          onBlur={handleInputBlur}
        />
        <div id="home-search-description" className="sr-only">
          Search bar to find Alphabets, Artworks, and Creators
        </div>
        <button
          tabIndex={isFocused ? 0 : -1}
          type="button"
          className="cursor-pointer transition-colors text-accent-contrast bg-accent hover:bg-accent-fade focus:ring-2 focus:outline-none focus:ring-accent-contrast font-medium rounded-4xl text-sm px-4 py-2 w-24"
          onClick={handleButtonClick}
        >
          Search
        </button>
      </div>
    </form>
  );
};

export default SearchBar;
