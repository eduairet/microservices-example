import { type ReactNode, type FC } from 'react';

export enum HeadingLevel {
  H1 = 'h1',
  H2 = 'h2',
  H3 = 'h3',
  H4 = 'h4',
  H5 = 'h5',
  H6 = 'h6',
}

interface IProps {
  level: HeadingLevel;
  children: ReactNode;
  className?: string;
}

const headingClasses: Record<HeadingLevel, string> = {
  [HeadingLevel.H1]: 'text-5xl font-bold',
  [HeadingLevel.H2]: 'text-4xl font-semibold',
  [HeadingLevel.H3]: 'text-3xl font-medium',
  [HeadingLevel.H4]: 'text-2xl font-medium',
  [HeadingLevel.H5]: 'text-xl font-normal',
  [HeadingLevel.H6]: 'text-lg font-normal',
};

const Heading: FC<IProps> = ({ level, children, className }) => {
  const Tag = level;
  const headingClassName = headingClasses[level];

  return (
    <Tag
      className={`font-heading text-accent break-all text-center ${headingClassName} ${className}`.trim()}
    >
      {children}
    </Tag>
  );
};

export default Heading;
