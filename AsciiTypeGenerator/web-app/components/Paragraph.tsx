import { type FC, type ReactNode } from 'react';

interface ParagraphProps {
  children: ReactNode;
  className?: string;
}

const Paragraph: FC<ParagraphProps> = ({ children, className = '' }) => {
  return <p className={`text-lg text-balance max-w-[65ch] ${className}`}>{children}</p>;
};

export default Paragraph;
