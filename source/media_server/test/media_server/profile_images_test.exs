defmodule MediaServer.ProfileImagesTest do
  use MediaServer.DataCase

  alias MediaServer.ProfileImages

  describe "profile_image" do
    alias MediaServer.ProfileImages.ProfileImage

    @valid_attrs %{image: "some image", user: "7488a646-e31f-11e4-aace-600308960662"}
    @update_attrs %{image: "some updated image", user: "7488a646-e31f-11e4-aace-600308960668"}
    @invalid_attrs %{image: nil, user: nil}

    def profile_image_fixture(attrs \\ %{}) do
      {:ok, profile_image} =
        attrs
        |> Enum.into(@valid_attrs)
        |> ProfileImages.create_profile_image()

      profile_image
    end

    test "list_profile_image/0 returns all profile_image" do
      profile_image = profile_image_fixture()
      assert ProfileImages.list_profile_image() == [profile_image]
    end

    test "get_profile_image!/1 returns the profile_image with given id" do
      profile_image = profile_image_fixture()
      assert ProfileImages.get_profile_image!(profile_image.id) == profile_image
    end

    test "create_profile_image/1 with valid data creates a profile_image" do
      assert {:ok, %ProfileImage{} = profile_image} = ProfileImages.create_profile_image(@valid_attrs)
      assert profile_image.image == "some image"
      assert profile_image.user == "7488a646-e31f-11e4-aace-600308960662"
    end

    test "create_profile_image/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = ProfileImages.create_profile_image(@invalid_attrs)
    end

    test "update_profile_image/2 with valid data updates the profile_image" do
      profile_image = profile_image_fixture()
      assert {:ok, %ProfileImage{} = profile_image} = ProfileImages.update_profile_image(profile_image, @update_attrs)
      assert profile_image.image == "some updated image"
      assert profile_image.user == "7488a646-e31f-11e4-aace-600308960668"
    end

    test "update_profile_image/2 with invalid data returns error changeset" do
      profile_image = profile_image_fixture()
      assert {:error, %Ecto.Changeset{}} = ProfileImages.update_profile_image(profile_image, @invalid_attrs)
      assert profile_image == ProfileImages.get_profile_image!(profile_image.id)
    end

    test "delete_profile_image/1 deletes the profile_image" do
      profile_image = profile_image_fixture()
      assert {:ok, %ProfileImage{}} = ProfileImages.delete_profile_image(profile_image)
      assert_raise Ecto.NoResultsError, fn -> ProfileImages.get_profile_image!(profile_image.id) end
    end

    test "change_profile_image/1 returns a profile_image changeset" do
      profile_image = profile_image_fixture()
      assert %Ecto.Changeset{} = ProfileImages.change_profile_image(profile_image)
    end
  end
end
