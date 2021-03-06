using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class AlbumTest : IDisposable
  {
    
    public void Dispose()
    {
      Album.ClearAll();
    }
    
    [TestMethod]
    public void AlbumConstructor_CreatesInstanceOfAlbum_Album()
    {
      Album newAlbum = new Album("test title");
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string title = "Ziggy Stardust";

      Album newAlbum = new Album(title);
      string result = newAlbum.Title;

      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetTitle_SetsTitle_String()
    {
      string newTitle = "self-titled";
      Album testAlbum = new Album(newTitle);
      string updatedTitle = "Alanis Morisette";
      testAlbum.Title = updatedTitle;
      Assert.AreEqual("Alanis Morisette", testAlbum.Title);
    }

    [TestMethod]
    public void GetAll_ReturnsList_List()
    {
      Album newAlbum1 = new Album("Album 1");
      Album newAlbum2 = new Album("Album 2");
      List<Album> newList = new List<Album> { newAlbum1, newAlbum2 };

      List<Album> result = Album.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_AssignIdUponAlbumInstantiation_Int()
    {
      string albumTitle = "Barabajagal";
      Album newAlbum = new Album(albumTitle);

      int result = newAlbum.Id;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void FindAlbum_ReturnsAlbumInstanceMatchedById_Album()
    {
      string newTitle01 = "Jupiter";
      string newTitle02 = "Mars";
      Album newAlbum01 = new Album(newTitle01);
      Album newAlbum02 = new Album(newTitle02);
      Album result = Album.Find(2);
      Console.WriteLine("{0}, {1}, {2}", newAlbum01.Id, newAlbum02.Id, result.Id);
      Assert.AreEqual(newAlbum02, result);
    }
  }
}