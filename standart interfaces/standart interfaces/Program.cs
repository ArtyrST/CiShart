using System;
using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Movie : ICloneable, IComparable<Movie>
{
    public string title;
    public Director director;
    public string country;
    public Genre genre;
    public int year;
    public short rating;

    public object Clone()
    {
        Movie copy = (Movie)this.MemberwiseClone();
        copy.director = new Director { 
            FirstName = this.director.FirstName,
            LastName = this.director.LastName,
        };
        return copy;
    }

    public int CompareTo(Movie? other)
    {
        return this.title.CompareTo(other.title);
    }

    public string ToString()
    {
        return $"Title: {this.title}, director: {director.FirstName} {director.LastName}, country: {this.country}, genre: {this.genre}, year: {this.year}, rate: {this.rating}";
    }

}
class CompareByYear : IComparer<Movie>
{
    public int Compare(Movie? x, Movie? y)
    {
        return x.year.CompareTo(y.year);
    }
}
class CompareByRating : IComparer<Movie>
{
    public int Compare(Movie? x, Movie? y)
    {
        return x.rating.CompareTo(y.rating);
    }
}
class Director : ICloneable
{
    public string FirstName;
    public string LastName;

    public object Clone()
    {
        Director copy = (Director)this.MemberwiseClone();
        return copy;
    }
}

enum Genre
{
    Horror,
    travel,
    comedy,
}
class Cinema : IEnumerable
{

    public Movie[] movies;
    public string adress;



    IEnumerator IEnumerable.GetEnumerator()
    {
        return movies.GetEnumerator();
    }
    public void Sort(IComparer<Movie> comporator)
    {
        Array.Sort(movies, comporator);
    }
}
internal class Program
{
    static void Main(string[] args)
    {



    }
}

