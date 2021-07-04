defmodule MediaServer.UserMediaTest do
  use MediaServer.DataCase

  alias MediaServer.UserMedia

  describe "profile_image" do
    alias MediaServer.UserMedia.ProfileImage

    @valid_attrs %{imagePath: "some imagePath", user: "some user"}
    @update_attrs %{imagePath: "some updated imagePath", user: "some updated user"}
    @invalid_attrs %{imagePath: nil, user: nil}

    def profile_image_fixture(attrs \\ %{}) do
      {:ok, profile_image} =
        attrs
        |> Enum.into(@valid_attrs)
        |> UserMedia.create_profile_image()

      profile_image
    end

    test "list_profile_image/0 returns all profile_image" do
      profile_image = profile_image_fixture()
      assert UserMedia.list_profile_image() == [profile_image]
    end

    test "get_profile_image!/1 returns the profile_image with given id" do
      profile_image = profile_image_fixture()
      assert UserMedia.get_profile_image!(profile_image.id) == profile_image
    end

    test "create_profile_image/1 with valid data creates a profile_image" do
      assert {:ok, %ProfileImage{} = profile_image} = UserMedia.create_profile_image(@valid_attrs)
      assert profile_image.imagePath == "some imagePath"
      assert profile_image.user == "some user"
    end

    test "create_profile_image/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = UserMedia.create_profile_image(@invalid_attrs)
    end

    test "update_profile_image/2 with valid data updates the profile_image" do
      profile_image = profile_image_fixture()
      assert {:ok, %ProfileImage{} = profile_image} = UserMedia.update_profile_image(profile_image, @update_attrs)
      assert profile_image.imagePath == "some updated imagePath"
      assert profile_image.user == "some updated user"
    end

    test "update_profile_image/2 with invalid data returns error changeset" do
      profile_image = profile_image_fixture()
      assert {:error, %Ecto.Changeset{}} = UserMedia.update_profile_image(profile_image, @invalid_attrs)
      assert profile_image == UserMedia.get_profile_image!(profile_image.id)
    end

    test "delete_profile_image/1 deletes the profile_image" do
      profile_image = profile_image_fixture()
      assert {:ok, %ProfileImage{}} = UserMedia.delete_profile_image(profile_image)
      assert_raise Ecto.NoResultsError, fn -> UserMedia.get_profile_image!(profile_image.id) end
    end

    test "change_profile_image/1 returns a profile_image changeset" do
      profile_image = profile_image_fixture()
      assert %Ecto.Changeset{} = UserMedia.change_profile_image(profile_image)
    end
  end
end
