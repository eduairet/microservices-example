import { SVGProps, type FC, ReactNode } from 'react';

interface IProps extends SVGProps<SVGSVGElement> {
  width?: number;
  height?: number;
  viewBox?: string;
  children: ReactNode;
}

const IconWrapper: FC<IProps> = ({
  width = 24,
  height = 24,
  viewBox = '0 0 24 24',
  children,
  ...props
}) => (
  <svg
    xmlns="http://www.w3.org/2000/svg"
    width={width}
    height={height}
    viewBox={viewBox}
    {...props}
  >
    {children}
  </svg>
);

export default IconWrapper;
