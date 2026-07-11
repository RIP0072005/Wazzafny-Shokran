export interface Job {
  id: number;
  title: string;
  description: string;
  skills: string;
  location: string;
  locationType: string;
  salary: number;
  companyId: number;
  companyName?: string;
  categoryNames?: string[];
}

export interface CreateJobDto {
  title: string;
  description: string;
  skills: string;
  location: string;
  locationType: string;
  salary: number;
  companyId: number;
  categoryIds: number[];
}